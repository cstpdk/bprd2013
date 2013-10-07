- Exercise 3.2

-   Regexp:
-       b*a?(b+a?)*
-   NFA:
-       SEE 3.2.NFA.png
-   DFA:
-       States:

-       s_1 = {1,2,4}
-       s_2 (med a) = {3,6,7,16,8,9,10,11,12}
-       s_3 (med b) = {4,5,6,7,16,8,9,10,11,12,13,14,15}

-       SEE 3.2.DFA.png

- Exercise 3.3
-   let z = (17) in z + 2 * 3 end EOF

-   A   Expr EOF
-   F   LET Expr = Expr IN Expr end EOF
-   G   LET Expr = Expr IN Expr * Expr EOF
-   C   LET Expr = Expr IN Expr * 3 EOF
-   H   LET Expr = Expr IN Expr + Expr * 3 EOF
-   C   LET Expr = Expr IN Expr + 2 * 3 EOF
-   B   LET Expr = Expr IN z + 2 * 3 EOF
-   C   LET Expr = 17 IN z + 2 * 3 EOF
-   B   LET z = 17 IN z + 2 * 3 EOF


