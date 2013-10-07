all: 3.6 3.7

lexer:
	fslex.exe --unicode Expr/ExprLex.fsl

parser:
	fsyacc.exe --module ExprPar Expr/ExprPar.fsy

build: lexer parser

3.6: 
	fsharpi --readline -r ~/lib/fsharppower/bin/FSharp.PowerPack.dll Expr/Absyn.fs Expr/ExprPar.fs Expr/ExprLex.fs Expr/Parse.fs Expr/Expr.fs < 36.fs > 3.6.out
	cat 3.6.out

3.7:
	fsharpi --readline -r ~/lib/fsharppower/bin/FSharp.PowerPack.dll Expr/Absyn.fs Expr/ExprPar.fs Expr/ExprLex.fs Expr/Parse.fs Expr/Expr.fs < 37.fs > 3.7.out
	cat 3.7.out

clean:
	rm *.out
