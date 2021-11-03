module HW6.App

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open Microsoft.Extensions.DependencyInjection
open Giraffe

open ResultBuilder
open Calculator
open Expression

let parametersCalculatorHandler:HttpHandler =
    fun next ctx ->
        let resultCalculation = result {
            let! expression = ctx.TryBindQueryString<Expression>()
            let! result = tryCalculate expression
            return result
        }
        
        match resultCalculation with
        | Ok ok -> (setStatusCode 200 >=> text (ok.ToString())) next ctx
        | Error error -> (setStatusCode 400 >=> text error) next ctx
            
let webApp =
    choose [
        GET >=> choose [
                    route "/" >=> text "Write /calculate?v1=*&operation=*&v2=* in search line"
                    route "/calculate" >=> parametersCalculatorHandler ]
        setStatusCode 404 >=> text "Not Found" ]

type Startup() =
    member _.ConfigureServices (services : IServiceCollection) =
        services.AddGiraffe() |> ignore

    member _.Configure (app : IApplicationBuilder)
                        (_ : IHostEnvironment)
                        (_ : ILoggerFactory) =
        app.UseGiraffe webApp
             
[<EntryPoint>]
let main args =
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(
            fun webHostBuilder ->
                webHostBuilder
                    .UseStartup<Startup>()
                    |> ignore)
        .Build()
        .Run()
    0