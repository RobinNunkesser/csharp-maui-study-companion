using System;
using System.Threading.Tasks;

namespace Italbytz.Ports.Common
{
    /// <summary> 
    /// A Service asynchronously executes business logic for a use case.
    /// </summary>
    public interface IService<in TInDTO, TOutDTO>
    {
        /// <summary>
        /// Executes the use case.
        /// </summary>
        /// <param name="inDTO">Encapsulated inDTO parameters.</param>
        Task<TOutDTO> Execute(TInDTO inDTO);
    }

    /// <summary> 
    /// A Service asynchronously executes business logic for a use case.
    /// </summary>
    public interface IService<TOutDTO>
    {
        /// <summary>
        /// Executes the use case.
        /// </summary>
        Task<TOutDTO> Execute();
    }
}
