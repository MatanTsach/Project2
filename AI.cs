using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Threading.Tasks;
public class AI
{
    private static int m_AIrow = -1;
    private static int m_AIcolumn = -1;
    public static int AIrow {
        set{
            m_AIrow = value;
        }
        get{
            return m_AIrow;
        }
    }
    public static int AIcolumn {
        set{
            m_AIcolumn = value;
        }
        get{
            return m_AIcolumn;
        }
    }
    public static async Task AImain(string[,] gameBoard)
    {
        string[,] gameState = {
            {"X", "X", "-"},
            {"X", "X", "-"},
            {"O", "O", "-"}
        };

        string userMessage = "Your turn, you are 'O', we are playing reverse tic tac toe with 3X3 board where '-' is free position, what are the index of your move? return me as (row, column) format, give me one position";

        string apiKey = "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";
        string apiEndpoint = "https://api.openai.com/v1/chat/completions";

        using (var httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            Console.WriteLine("here3 :" + GetMatrixAsString(gameBoard));
            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "system", content = "" },
                    new { role = "user", content = GetMatrixAsString(gameBoard) },
                    new { role = "user", content = userMessage }
                },
                max_tokens = 200
            };
            
            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            Console.WriteLine("here1" );
            //var response = await httpClient.PostAsync(apiEndpoint, content);
            var response = httpClient.PostAsync(apiEndpoint, content).Result;
            Console.WriteLine("here2" + response);
            var responseJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var responseBody = JsonSerializer.Deserialize<ChatGptResponse>(responseJson);
                var generatedMove = responseBody.choices[0].message.content;
                Console.WriteLine("Generated move: " + generatedMove);
                string move = extractMove(generatedMove);
                Setmove(move);
            }
            else
            {
                var errorResponse = JsonSerializer.Deserialize<ChatGptErrorResponse>(responseJson);
                Console.WriteLine("API request failed. Error: " + errorResponse.error.message);
            }
        }
    }
    public static void Setmove(string coordinate)
    {
        coordinate = coordinate.Trim('(', ')');

        // Split the string into X and Y values
        string[] coordinates = coordinate.Split(',');

        // Parse the X and Y values
        int x = int.Parse(coordinates[0].Trim());
        int y = int.Parse(coordinates[1].Trim());
        AIrow = x;
        AIcolumn = y;
    }
    static string extractMove(string generatedMove)
    {
        int firstPosition = generatedMove.IndexOf("(");
        int lastPosition = generatedMove.IndexOf(")");
        return generatedMove.Substring(firstPosition,(lastPosition-firstPosition)+1);
    }

    static string GetMatrixAsString(string[,] matrix)
    {
        StringBuilder sb = new StringBuilder();

        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                sb.Append(matrix[i, j]);

                if (j < columns - 1)
                {
                    sb.Append(" ");
                }
            }

            if (i < rows - 1)
            {
                sb.Append("\n");
            }
        }

        return sb.ToString();
    }
}

public class ChatGptResponse
{
    public ChatGptChoice[] choices { get; set; }
}

public class ChatGptChoice
{
    public ChatGptMessage message { get; set; }
}

public class ChatGptMessage
{
    public string content { get; set; }
}

public class ChatGptErrorResponse
{
    public ChatGptError error { get; set; }
}

public class ChatGptError
{
    public string message { get; set; }
}
