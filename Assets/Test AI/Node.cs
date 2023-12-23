namespace CatUp
{
    public abstract class Node
    {
        public bool exitCondition;

        public abstract void OnStateEnter();

        public abstract void OnStateExit();

        public abstract void Perform();
    }

}