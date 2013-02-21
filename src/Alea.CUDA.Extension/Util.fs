﻿module Alea.CUDA.Extension.Util

open Alea.CUDA

let [<ReflectedDefinition>] WARP_SIZE = 32
let [<ReflectedDefinition>] LOG_WARP_SIZE = 5

let divup num den = (num + den - 1) / den

let ispow2 x = x &&& x-1 = 0
  
let nextpow2 i =
    let mutable x = i - 1
    x <- x ||| (x >>> 1)
    x <- x ||| (x >>> 2)
    x <- x ||| (x >>> 4)
    x <- x ||| (x >>> 8)
    x <- x ||| (x >>> 16)
    x + 1
     
let log2 (arg:int) =
    if arg = 0 then failwith "argument cannot be zero"
    let mutable n = arg
    let mutable logValue = 0
    while n > 1 do
        logValue <- logValue + 1
        n <- n >>> 1
    logValue

let padding alignment size =
    match alignment with
    | 0 -> 0
    | alignment -> (divup size alignment) * alignment - size

let dim3str (d:dim3) = sprintf "(%dx%dx%d)" d.x d.y d.z

let kldiag (stat:Engine.KernelExecutionStats) =
    printfn "%s: %s %s %6.2f%% %.6f ms"
        stat.Kernel.Name
        (stat.LaunchParam.GridDim |> dim3str)
        (stat.LaunchParam.BlockDim |> dim3str)
        (stat.Occupancy * 100.0)
        stat.TimeSpan

module NumericLiteralG =
    let [<ReflectedDefinition>] inline FromZero() = LanguagePrimitives.GenericZero
    let [<ReflectedDefinition>] inline FromOne() = LanguagePrimitives.GenericOne
    let [<ReflectedDefinition>] inline FromInt32 (i:int) = Alea.CUDA.DevicePrimitive.genericNumberFromInt32 i

