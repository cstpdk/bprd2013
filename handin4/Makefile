all: lexer parser fsi

lexer:
	fslex.exe --unicode Fun/FunLex.fsl

parser:
	fsyacc.exe --module FunPar Fun/FunPar.fsy

.PHONY:	clean 6.4

6.1: lexer parser
	fsharpi --readline -r /home/csp/lib/fsharppower/bin/FSharp.PowerPack.dll Fun/Absyn.fs Fun/FunPar.fs Fun/FunLex.fs Fun/Parse.fs Fun/Fun.fs Fun/ParseAndRun.fs Fun/HigherFun.fs Fun/ParseAndRunHigher.fs < 61.fs > 6.1.out 

6.2: lexer parser
	fsharpi --readline -r /home/csp/lib/fsharppower/bin/FSharp.PowerPack.dll Fun/Absyn.fs Fun/FunPar.fs Fun/FunLex.fs Fun/Parse.fs Fun/HigherFun.fs Fun/ParseAndRunHigher.fs < 62.fs > 6.2.out 

6.4:
	pdflatex -output-directory=target 6.4.tex

6.5: lexer parser
	fsharpi --readline -r /home/csp/lib/fsharppower/bin/FSharp.PowerPack.dll Fun/Absyn.fs Fun/FunPar.fs Fun/FunLex.fs Fun/Parse.fs Fun/TypeInference.fs Fun/ParseAndType.fs < 65.fs > 6.5.out 

fsi: lexer parser
	fsharpi --readline -r /home/csp/lib/fsharppower/bin/FSharp.PowerPack.dll Fun/Absyn.fs Fun/FunPar.fs Fun/FunLex.fs Fun/Parse.fs Fun/HigherFun.fs Fun/ParseAndRunHigher.fs Fun/TypeInference.fs Fun/ParseAndType.fs 

clean:
	rm *.out
