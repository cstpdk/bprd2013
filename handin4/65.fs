open Absyn;;
open ParseAndType;;

//inferType (fromString "let f x = 1 in f 7 + f false end");;

fromString "let f x = 1 in f f end";;
inferType(it);;

(*
fromString "let f g = g g in f end";;
inferType(it);;
*)
printfn @"  let f g = g g in f end \n can't be typed because it
            attempts to call g with itself, but it has no way
            to infer the type of g. Creating a form of circular dependency";;

fromString "let f x = let g y = y in g false end in f 42 end";;
inferType(it);;

fromString @"   let f x = 
                    let g y = if true then y else x 
                    in g false end 
                in f 42 end";;
(*
inferType(it);;
*)
printfn @"  let f x = let g y = if true then y else x in g false end
            can't be typed because it can't compile due to missing
            in statement. But then i turned the page and saw the 'missing' statement :). Now it can't type due to the fact that we parse and int to function f which expects a bool";;

fromString @"   let f x = 
                    let g y = if true then y else x
                    in g false end
                in f true end";;
inferType(it);;


printfn("________________________________________\n (2)\n");

printfn("\nbool -> bool\n");;
fromString @"let f x = if x then x else false
                  in f end";;
inferType(it);;

printfn("\nint -> int\n");;
fromString @"let f x = x+x in f end";;
inferType(it);;

printfn("\nint -> int -> int\n");;
fromString @"   let f x = x(1)+1
                in f end";;

inferType(it);;

printfn("\n a -> b -> a \n");;
fromString @"   let f x = 
                    let g y = x in g end
                in f end";;

inferType(it);;

printfn("\n a -> b -> b \n");;
fromString @"   let f x = 
                    let g y = y in g end
                in f end";;
inferType(it);;

printfn("\n ('a -> 'b) -> ('b -> 'c) -> ('a->'c)");;
fromString @"   let f a = 
                    let g b =   
                        let h c = b(a(c))
                        in h end
                    in g end 
                in f end
            ";;
inferType(it);;

printfn("\n 'a -> 'b \n")

fromString @"   let f a = 
                    let g b = b in f(a) end 
                in f end
            ";;
inferType(it);;

printfn("\n a \n");;

fromString @"   let f a = 
                    let b = f(a) in b end 
                in f(1) end
            ";;
inferType(it);;


#q;;
