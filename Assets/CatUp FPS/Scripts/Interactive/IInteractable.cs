namespace CatUp
{
    interface IInteractable
    {
        public string InteractableText { get; set; }
        public void Interact();
    }
}