all: lexer parser fsi

lexer:
	fslex.exe --unicode Fun/FunLex.fsl

parser:
	fsyacc.exe --module FunPar Fun/FunPar.fsy

4.1:
	fsharpi --readline -r /home/csp/lib/fsharppower/bin/FSharp.PowerPack.dll Fun/Absyn.fs Fun/FunPar.fs Fun/FunLex.fs Fun/Parse.fs Fun/Fun.fs Fun/ParseAndRun.fs < 41.fs > 4.1.out 
	cat 4.1.out

fsi:
	fsharpi --readline -r /home/csp/lib/fsharppower/bin/FSharp.PowerPack.dll Fun/Absyn.fs Fun/FunPar.fs Fun/FunLex.fs Fun/Parse.fs Fun/Fun.fs Fun/ParseAndRun.fs 

clean:
	rm *.out
