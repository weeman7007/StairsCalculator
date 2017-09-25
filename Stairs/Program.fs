// Application to calculate stairs
namespace StairsProgram

module Main =
    open System
    open Stairs
    open InputChecking

    printfn "Please note that this program conforms to regulations for INTERNAL PRIVATE STAIRS ONLY.\nThis functionality may be subject to revision.\n"
    //Checks the value entered by the user is an integer
    let heightStr = "Please enter the height difference between floors in mm:" 
    printfn "%s" heightStr 
    let heightDiff = verifyInput(Console.ReadLine()) heightStr

    //Performs calculation for the number of stairs (straight staircase)
    let steps, stepHeight, stairSpace = calculateStraightStairs heightDiff
    
    //Prints the number of rises, and the height of each rise
    printfn "Step height: %s mm, number of steps (stair rises including to landing): %i" (stepHeight.ToString()) steps
    printfn "Total space required for staircase: %i" stairSpace

    printfn "Press any key to exit.."
    Console.ReadKey() |> ignore