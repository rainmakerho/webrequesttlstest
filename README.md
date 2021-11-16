# webrequesttlstest
Use WebRequest Get Url Result for TLS version testing
```csharp
#webReqTest "url" tlsoption
#webReqTest "url" tls11
webReqTest "https://api.nuget.org/v3/index.json" 1

#webReqTest "url" tls12
webReqTest "https://api.nuget.org/v3/index.json" 2

#webReqTest "url" tls12 + tls11
webReqTest "https://api.nuget.org/v3/index.json" 3

#webReqTest "url" tls(default)
webReqTest "https://api.nuget.org/v3/index.json"
```