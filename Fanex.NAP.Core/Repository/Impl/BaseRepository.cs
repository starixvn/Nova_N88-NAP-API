namespace Fanex.N88.Core.Repository.Impl
{
    using System;
    using System.Collections;
    using Fanex.Data.Repository;
    using Fanex.N88.Core.Command;

    /// <summary>
    /// Repository base.
    /// </summary>
    /// <typeparam name="T">Object type.</typeparam>
    public class BaseRepository<T> : ReadonlyRepository<T>
    {
        /// <summary>
        /// Get command result.
        /// </summary>
        /// <param name="hash">Result data.</param>
        /// <returns>Command result.</returns>
        public CommandResult GetCommandResult(Hashtable hash)
        {
            var errCode = hash["errcode"];
            var errMsg = hash["errmsg"];

            return new CommandResult
            {
                Code = (errCode is DBNull) ? 0 : Convert.ToInt32(errCode),
                Message = (errMsg is DBNull) ? string.Empty : Convert.ToString(errMsg)
            };
        }
    }
}