lexer:
	fslex.exe --unicode MicroC/CLex.fsl

parser:
	fsyacc.exe --module CPar MicroC/CPar.fsy

fsi: lexer parser
	fsharpi --readline -r /home/csp/lib/fsharppower/bin/FSharp.PowerPack.dll MicroC/Absyn.fs MicroC/CPar.fs MicroC/CLex.fs MicroC/Parse.fs MicroC/Interp.fs MicroC/ParseAndRun.fs

8.1:
	fsharpi --readline -r /home/csp/lib/fsharppower/bin/FSharp.PowerPack.dll MicroC/Absyn.fs MicroC/CPar.fs MicroC/CLex.fs MicroC/Parse.fs MicroC/Machine.fs MicroC/Comp.fs MicroC/ParseAndComp.fs < 81.fs
