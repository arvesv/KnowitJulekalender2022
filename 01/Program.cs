

// Helper functions
async Task<string> DownloadFileFromTheInternetAsync(string uri)
{
    using var client = new HttpClient();

    using var response = await client.GetAsync(uri);
    response.EnsureSuccessStatusCode();
    return await response.Content.ReadAsStringAsync();
}


string? Decode(string message, Dictionary<string, string?> dic)
{
    foreach (var key in dic)
        if (message.StartsWith(key.Key))
        {
            if (message.Length == key.Key.Length) return key.Value;

            var z = Decode(message[key.Key.Length..], dic);
            if (z != null) return key.Value + " " + z;
        }

    return null;
}


// Read the dictionary into a Dictionary
const string dictionaryUrl =
    "https://julekalender-backend.knowit.no/rails/active_storage/blobs/redirect/eyJfcmFpbHMiOnsibWVzc2FnZSI6IkJBaHBBb1VEIiwiZXhwIjpudWxsLCJwdXIiOiJibG9iX2lkIn19--2f6bcd547b6ffe889579dd8a1af8249693a333d7/dictionary.txt?disposition=inline";
var body = await DownloadFileFromTheInternetAsync(dictionaryUrl);
Dictionary<string, string> z = body
    .Split('\n')
    .Where(x => !string.IsNullOrEmpty(x))
    .Select(x => x.Split(','))
    .ToDictionary(
        r => r[0],
        r => r[1]
    );


Console.WriteLine(body);

const string wishlistUrl =
    "https://julekalender-backend.knowit.no/rails/active_storage/blobs/redirect/eyJfcmFpbHMiOnsibWVzc2FnZSI6IkJBaHBBdkFDIiwiZXhwIjpudWxsLCJwdXIiOiJibG9iX2lkIn19--7400c6d0a99d17a53b0cdcb0b32a40026c0b44a2/letter.txt?disposition=inline";
var wishlist = await DownloadFileFromTheInternetAsync(wishlistUrl);

var result = Decode(wishlist, z);

Console.WriteLine(result.Length);