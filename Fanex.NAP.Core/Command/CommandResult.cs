namespace Fanex.N88.Core.Command
{
    /// <summary>
    /// Command result.
    /// </summary>
    public class CommandResult : CommandResultBase
    {
        public override bool IsSuccessful
        {
            get { return this.Code == 0; }
        }
    }
}