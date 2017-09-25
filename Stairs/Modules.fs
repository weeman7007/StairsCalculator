namespace StairsProgram
module InputChecking = 
    //Recursively called until integer is entered by the user

    let rec verifyInput input str = 
        //Performs the attempt to change to integer
        let trycastint input =
            try
                int input
            with
            | :? System.FormatException as ex -> printfn "%s" ex.Message; -1 //The semicolon allows us to separate expressions on one line, the zero is to change the type of the "with" from "unit" to "int"
                                                                //This fixed an error that occurred by having the try type int but with type unit. The zero is an arbitrary value.
                                                                
        let result = trycastint input

        if result = -1 then
            printfn "%s" str
            verifyInput(System.Console.ReadLine()) str
        else
            result

module Stairs =
    let minStepHeight = 165 // 2rise + going...
    let maxStepHeight =  220
    let maxStairAngle = 42
    //let minStairAngle =
    let minStepGoing = 220
    let maxStepGoing = 300

    //Function that checks to see if the number is whole, and returns the number of decimal places
    let getDecimalPlaces input = 
        let strInput = input.ToString()
        let index = strInput.IndexOf(".")

        if index = -1 then
            0
        else
            strInput.Remove(0, index + 1).Length

    //Function to get the fewest steps that could possibly be allowed
    let getMinSteps input = 
        let partialSteps = float input / float maxStepHeight
        int (ceil partialSteps)

    //Function to get the most steps that are allowed
    let getMaxSteps input =
        let partialSteps = float input / float minStepHeight
        int (floor partialSteps) 
    
    let rec getGoing str =
        let going = InputChecking.verifyInput(System.Console.ReadLine()) str

        if going < minStepGoing || going > maxStepGoing then
            printfn "Please enter a going between %i and %i" minStepGoing maxStepGoing
            getGoing str
        else
            going

    //Calculates how many steps are needed, and the height of each step for a given height. Produces results for straight stairs only.
    let calculateStraightStairs heightDiff =
        let mutable bestDp = 100
        let mutable bestHeight = 0.0
        let mutable steps = 0

        let minSteps = getMinSteps heightDiff
        let maxSteps = getMaxSteps heightDiff

        let goingStr = "Please enter the going for the stairs in mm:"
        printfn "%s"  goingStr
        let going = getGoing goingStr

        //Calculates the best possible scenario for steps - ie. not needing too many, and each step being the wholest mm it possibly can.
        for i = minSteps to maxSteps do
            let stepHeight = float heightDiff / float i
            let dp = getDecimalPlaces stepHeight
            
            if dp < bestDp then
                bestDp <- dp
                bestHeight <- stepHeight
                steps <- i

        let stairSpace = going * steps

        steps, bestHeight, stairSpace