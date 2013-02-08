﻿module Alea.CUDA.Extension.NormalDistribution.ShawBrickmanExtended

open Alea.CUDA

[<ReflectedDefinition>]
let inverseNormalCdf v =
    let P1 = 1.2533141373154989811
    let P2 = 5.5870183514814983104
    let P3 = 9.9373788223105148469
    let P4 = 9.11745910783758368
    let P5 = 4.6865666928347513004
    let P6 = 1.3841649695441184484
    let P7 = 0.23434950424605615377
    let P8 = 0.022306824510199724768
    let P9 = 0.0011538603964070818722
    let P10 = 0.000030796620691411567563
    let P11 = 3.9115723028719510263e-7
    let P12 = 2.0589573468131996933e-9
    let P13 = 3.3944224725087481454e-12
    let P14 = 7.3936480912071325978e-16 
    let Q1 = 1.0
    let Q2 = 4.9577956835689939051
    let Q3 = 9.9793129245112074476
    let Q4 = 10.574454910639356539
    let Q5 = 6.4247521669505779535
    let Q6 = 2.3008904864351121026
    let Q7 = 0.48545999687461771635
    let Q8 = 0.059283082737079006352
    let Q9 = 0.0040618506206078995821
    let Q10 = 0.00014919732843986856251
    let Q11 = 2.7477061392049947066e-6
    let Q12 = 2.2815008011613816939e-8
    let Q13 = 7.0445790305953963457e-11
    let Q14 = 5.1535907808963289678e-14

    let sgn = if v >= 0.5 then 1 else -1
    let vv = if sgn = -1 then v else 1.0 - v
    let z = -log(2.0 * vv)   

    let num = (P1+z*(P2+z*(P3+z*(P4+z*(P5+z*(P6+z*(P7+z*(P8+z*(P9+z*(P10+z*(P11+z*(P12+z*(P13+P14*z)))))))))))))
    let den = (Q1+z*(Q2+z*(Q3+z*(Q4+z*(Q5+z*(Q6+z*(Q7+z*(Q8+z*(Q9+z*(Q10+z*(Q11+z*(Q12+z*(Q13+Q14*z)))))))))))))
 
    float(sgn) * z * num / den


