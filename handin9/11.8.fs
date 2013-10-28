open Icon;;

// 3 5 7 9
run(Every(Write(Prim("+",CstI 1,Prim("*",CstI 2,FromTo(1, 4))))));;

// 21 22 31 32 41 42
//run(Every(Write(Prim("+",FromTo(11,12),Prim("*",FromTo(1,3),CstI 10)))));;
run(Every(Write(Prim("+",Prim("*",CstI 10, FromTo(2,4)),FromTo(1,2)))));;
////
// Multiples of 7 greater than 50
run(Write(Prim("<", CstI 50, Prim("*", CstI 7, FromTo(1,10)))));;

// sqrt
run(Every(Write(Prim1("sqr",FromTo(3,6)))));;
// Even
run(Every(Write(Prim1("even",FromTo(1,7)))));;

// Multiplies
run(Every(Write(Prim1("multiples",CstI 4))));;

#q;;
