﻿using Notes.Models;

namespace Notes.ServerRequest;

public class ServerUrls
{
    private static string SerUrl = "http://localhost:5239";
    public static string GetToken(Login login) => $"{SerUrl}/api/User/V1/GetToken?uName={login.userNo}&uPassword={login.password}";
}