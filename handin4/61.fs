open ParseAndRunHigher;;

printfn "\n"

printfn "Example from readme"
run (fromString @"let twice f = let g x = f(f(x)) in g end 
                    in let mul3 z = z*3 in twice mul3 2 end end");;


printfn "Program 1"
run (fromString @"let add x = let f y = x+y in f end
                  in add 2 5 end");;

printfn "Program 2"
run (fromString @"let add x = let f y = x+y in f end
                  in let addtwo = add 2
                     in addtwo 5 end
                  end");;

printfn "Program 3"
run (fromString @"let add x = let f y = x+y in f end
                  in let addtwo = add 2
                     in let x = 77 in addtwo 5 end
                     end
                  end");;

printfn "Program 4"
run (fromString @"let add x = let f y = x+y in f end
                  in add 2 end");;

printfn @"Program 4 returns a closure (with a closure) 
            because the closure in add (f) 
            never gets called. The innermost closure
            is returned because the body of the f closure
            calls f with no arguments"
#q;;

\n
