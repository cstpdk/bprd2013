7.1
  Prog
    [Fundec // Top level declaration
       (null,"main",[(TypI, "n")], 
        Block // Statement
          [Stmt // Statement
             (While // Statement
                (Prim2 (">",Access (AccVar "n"),CstI 0), // expr * expr
                 Block // Statement
                   [Stmt (Expr (Prim1 ("printi",Access (AccVar "n")))); //Statement * Statement * expr * expr * access
                    Stmt // Statement
                      (Expr // Statement
                         (Assign // Expr
                            (AccVar "n",Prim2 ("-",Access (AccVar "n"),CstI 1))))])); // access * expr * expr * access * expr
           Stmt (Expr (Prim1 ("printc",CstI 10)))])] // Statement * Statement * expr * expr
