lexer:
	fslex.exe --unicode MicroC/CLex.fsl

parser:
	fsyacc.exe --module CPar MicroC/CPar.fsy

fsi: lexer parser
	fsharpi --readline -r /home/csp/lib/fsharppower/bin/FSharp.PowerPack.dll MicroC/Absyn.fs MicroC/CPar.fs MicroC/CLex.fs MicroC/Parse.fs MicroC/Interp.fs MicroC/ParseAndRun.fs

7.1:
	fsharpi --readline -r /home/csp/lib/fsharppower/bin/FSharp.PowerPack.dll MicroC/Absyn.fs MicroC/CPar.fs MicroC/CLex.fs MicroC/Parse.fs MicroC/Interp.fs MicroC/ParseAndRun.fs < 71.fs

7.2:
	fsharpi --readline -r /home/csp/lib/fsharppower/bin/FSharp.PowerPack.dll MicroC/Absyn.fs MicroC/CPar.fs MicroC/CLex.fs MicroC/Parse.fs MicroC/Interp.fs MicroC/ParseAndRun.fs < 72.fs

7.3: lexer parser
	fsharpi --readline -r /home/csp/lib/fsharppower/bin/FSharp.PowerPack.dll MicroC/Absyn.fs MicroC/CPar.fs MicroC/CLex.fs MicroC/Parse.fs MicroC/Interp.fs MicroC/ParseAndRun.fs < 73.fs

7.4: lexer parser
	fsharpi --readline -r /home/csp/lib/fsharppower/bin/FSharp.PowerPack.dll MicroC/Absyn.fs MicroC/CPar.fs MicroC/CLex.fs MicroC/Parse.fs MicroC/Interp.fs MicroC/ParseAndRun.fs < 74.fs
