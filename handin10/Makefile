func="addIFZRO"
lexer:
	fslex.exe --unicode MicroC/CLex.fsl

parser:
	fsyacc.exe --module CPar MicroC/CPar.fsy

fsi: lexer parser
	fsharpi --readline -r /home/csp/lib/fsharppower/bin/FSharp.PowerPack.dll MicroC/Absyn.fs MicroC/CPar.fs MicroC/CLex.fs MicroC/Parse.fs MicroC/Machine.fs MicroC/Comp.fs MicroC/ParseAndComp.fs 

12.1.out: lexer parser
	fsharpi --readline -r /home/csp/lib/fsharppower/bin/FSharp.PowerPack.dll MicroC/Absyn.fs MicroC/CPar.fs MicroC/CLex.fs MicroC/Parse.fs MicroC/Machine.fs MicroC/Contcomp.fs MicroC/Comp.fs MicroC/ParseAndComp.fs < 121.fs > 12.1.out

12.2.out: lexer parser
	fsharpi --readline -r /home/csp/lib/fsharppower/bin/FSharp.PowerPack.dll MicroC/Absyn.fs MicroC/CPar.fs MicroC/CLex.fs MicroC/Parse.fs MicroC/Machine.fs MicroC/Contcomp.fs MicroC/Comp.fs MicroC/ParseAndContcomp.fs < 122.fs > 12.2.out

12.3.out: lexer parser
	fsharpi --readline -r /home/csp/lib/fsharppower/bin/FSharp.PowerPack.dll MicroC/Absyn.fs MicroC/CPar.fs MicroC/CLex.fs MicroC/Parse.fs MicroC/Machine.fs MicroC/Contcomp.fs MicroC/Comp.fs MicroC/ParseAndContcomp.fs < 123.fs > 12.3.out

12.4.out: lexer parser
	fsharpi --readline -r /home/csp/lib/fsharppower/bin/FSharp.PowerPack.dll MicroC/Absyn.fs MicroC/CPar.fs MicroC/CLex.fs MicroC/Parse.fs MicroC/Machine.fs MicroC/Contcomp.fs MicroC/Comp.fs MicroC/ParseAndContcomp.fs < 124.fs > 12.4.out

test: lexer parser tests
	fsharpi --readline -r /home/csp/lib/fsharppower/bin/FSharp.PowerPack.dll MicroC/Absyn.fs MicroC/CPar.fs MicroC/CLex.fs MicroC/Parse.fs MicroC/Machine.fs MicroC/Contcomp.fs MicroC/Comp.fs MicroC/ParseAndComp.fs < tests/$(func).fs
