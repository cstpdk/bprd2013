using System;
using System.Collections.Generic;

abstract class Expr{
    abstract override public string ToString();
    abstract public int Eval(Dictionary<string,Expr> env);
    abstract public Expr Simplify();
}

/**
 * Object used to represent nothing
 */
class CstI : Expr { 
    protected readonly int i;

    public CstI(int i){
        this.i = i;
    }

    override public string ToString(){
        return ""+i;
    }

    override public int Eval(Dictionary<string,Expr> env){
        return i;
    }

    override public Expr Simplify(){
        return this;
    }

}
class Var : Expr { 
    protected readonly string name;

    public Var(string name){
        this.name = name;
    }

    override public string ToString(){
        return name;
    }

    override public int Eval(Dictionary<string,Expr> env){
        return env[name].Eval(env);
    }

    override public Expr Simplify(){
        return this;
    }
}

abstract class Binop : Expr{ }
class Add : Binop { 
    protected readonly Expr e1;
    protected readonly Expr e2;

    public Add(Expr e1,Expr e2){
        this.e1 = e1;
        this.e2 = e2;
    }

    override public string ToString(){
        return e1 + " + " + e2;
    }

    override public int Eval(Dictionary<string,Expr> env){
        return e1.Eval(env) + e1.Eval(env);
    }

    override public Expr Simplify(){
        if(e1.ToString() == "0")
            return e2.Simplify();
        else if(e2.ToString() == "0")
            return e1.Simplify();
        else
            return this;
    }
}
class Mul : Binop { 
    protected readonly Expr e1;
    protected readonly Expr e2;

    public Mul(Expr e1,Expr e2){
        this.e1 = e1;
        this.e2 = e2;
    }

    override public string ToString(){
        return e1 + " * " + e2;
    }

    override public int Eval(Dictionary<string,Expr> env){
        return e1.Eval(env) * e1.Eval(env);
    }
    override public Expr Simplify(){
        if(e1.ToString() == "0")
            return e2.Simplify();
        else if(e2.ToString() == "0")
            return e1.Simplify();
        else
            return this;
    }
}
class Sub : Binop { 
    protected readonly Expr e1;
    protected readonly Expr e2;

    public Sub(Expr e1,Expr e2){
        this.e1 = e1;
        this.e2 = e2;
    }

    override public string ToString(){
        return e1 + " - " + e2;
    }

    override public int Eval(Dictionary<string,Expr> env){
        return e1.Eval(env) - e1.Eval(env);
    }
    override public Expr Simplify(){
        if(e1.ToString() == "0")
            return e2.Simplify();
        else if(e2.ToString() == "0")
            return e1.Simplify();
        else if(e1.ToString() == e2.ToString())
            return new CstI(0);
        else
            return this;
    }
}

class week35{

    public static void Main(){
        Expr e1 = new Add(new CstI(17),new Var("z"));
        Expr e2 = new Sub(new CstI(17),new Var("z"));
        Expr e3 = new Mul(new CstI(17),new Var("z"));
        Expr e4 = new Add(new CstI(18),new Sub(new CstI(17),new Var("z")));

        Dictionary<string,Expr> env = new Dictionary<string,Expr>();

        env.Add("z",new CstI(4));

        int res = e4.Eval(env);

        Console.WriteLine(e1);
        Console.WriteLine(e2);
        Console.WriteLine(e3);
        Console.WriteLine(e4);
        Console.WriteLine(res);
    }
}

