using System.Collections.Generic;

namespace _07.ESGI.DesignPattern.Command
{
    public class Calculator
    {
        public int Result { get; private set; }

        public void Plus(int value)
        {
            Result += value;
        }

        public void Minus(int value)
        {
            Result -= value;
        }

        public void Multiply(int value)
        {
            Result *= value;
        }

        public void Divide(int value)
        {
            Result /= value;
        }
    }

    public abstract class CommandBase
    {
        protected readonly Calculator ctx;

        public CommandBase(Calculator ctx)
        {
            this.ctx = ctx;
        }

        public abstract void Do();
        public abstract void Undo();
    }

    public class SumCommand : CommandBase
    {
        private readonly int value;

        public SumCommand(Calculator ctx, int value)
            : base(ctx)
        {
            this.value = value;
        }

        public override void Do()
        {
            ctx.Plus(value);
        }

        public override void Undo()
        {
            ctx.Minus(value);
        }
    }

    public class MultiplyCommand : CommandBase
    {
        private readonly int value;

        public MultiplyCommand(Calculator ctx, int value)
            : base(ctx)
        {
            this.value = value;
        }

        public override void Do()
        {
            ctx.Multiply(value);
        }

        public override void Undo()
        {
            ctx.Divide(value);
        }
    }

    public class CLI
    {
        private Stack<CommandBase> commands;

        private Calculator calculator;

        public CLI()
        {
            commands = new Stack<CommandBase>();
            calculator = new Calculator();
        }

        public int Result()
        {
            return calculator.Result;
        }

        public void Compute(char operation, int value)
        {
            CommandBase cmd = null;

            switch (operation)
            {
                case '+':
                    cmd = new SumCommand(calculator, value);
                    break;
                case '*':
                    cmd = new MultiplyCommand(calculator, value);
                    break;
            }

            if (cmd != null)
            {
                cmd.Do();
                commands.Push(cmd);
            }
        }

        public void Undo()
        {
            if (commands.Count > 0)
            {
                var lastCommand = commands.Pop();

                lastCommand.Undo();
            }
        }
    }
}
