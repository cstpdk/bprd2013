lexer:
	fslex.exe --unicode MicroC/CLex.fsl

parser:
	fsyacc.exe --module CPar MicroC/CPar.fsy

fsi: lexer parser
	fsharpi --readline -r /home/csp/lib/fsharppower/bin/FSharp.PowerPack.dll MicroC/Absyn.fs MicroC/CPar.fs MicroC/CLex.fs MicroC/Parse.fs MicroC/Machine.fs MicroC/Comp.fs MicroC/ParseAndComp.fs 

8.1: lexer parser
	fsharpi --readline -r /home/csp/lib/fsharppower/bin/FSharp.PowerPack.dll MicroC/Absyn.fs MicroC/CPar.fs MicroC/CLex.fs MicroC/Parse.fs MicroC/Machine.fs MicroC/Comp.fs MicroC/ParseAndComp.fs < 81.fs

8.3: lexer parser
	fsharpi --readline -r /home/csp/lib/fsharppower/bin/FSharp.PowerPack.dll MicroC/Absyn.fs MicroC/CPar.fs MicroC/CLex.fs MicroC/Parse.fs MicroC/Machine.fs MicroC/Comp.fs MicroC/ParseAndComp.fs < 83.fs

8.4: lexer parser
	fsharpi --readline -r /home/csp/lib/fsharppower/bin/FSharp.PowerPack.dll MicroC/Absyn.fs MicroC/CPar.fs MicroC/CLex.fs MicroC/Parse.fs MicroC/Machine.fs MicroC/Comp.fs MicroC/ParseAndComp.fs < 84.fs

8.5: lexer parser
	fsharpi --readline -r /home/csp/lib/fsharppower/bin/FSharp.PowerPack.dll MicroC/Absyn.fs MicroC/CPar.fs MicroC/CLex.fs MicroC/Parse.fs MicroC/Machine.fs MicroC/Comp.fs MicroC/ParseAndComp.fs < 85.fs

8.6: lexer parser
	fsharpi --readline -r /home/csp/lib/fsharppower/bin/FSharp.PowerPack.dll MicroC/Absyn.fs MicroC/CPar.fs MicroC/CLex.fs MicroC/Parse.fs MicroC/Machine.fs MicroC/Comp.fs MicroC/ParseAndComp.fs < 86.fs
