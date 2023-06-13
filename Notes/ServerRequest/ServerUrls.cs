using Notes.Models;

namespace Notes.ServerRequest;

public class ServerUrls
{
    private static string SerUrl = @"http://121.196.199.65:18882";
    public static string GetToken(Login login) => $"{SerUrl}/api/User/V1/GetToken?uName={login.userNo}&uPassword={login.password}";

    public static string token = "";
}
