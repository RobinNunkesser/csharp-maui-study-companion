using System;
using System.Threading.Tasks;

namespace Italbytz.Ports.Common
{
    /// <summary> 
    /// An AsyncService asynchronously executes business logic for a use case.
    /// </summary>
    public interface IAsyncService<in TInDTO, TOutDTO>
    {
        /// <summary>
        /// Executes the use case.
        /// </summary>
        /// <param name="inDTO">Encapsulated inDTO parameters.</param>
        Task<TOutDTO> Execute(TInDTO inDTO);


    }

    /// <summary> 
    /// An AsyncService asynchronously executes business logic for a use case.
    /// </summary>
    public interface IAsyncService<TOutDTO>
    {
        /// <summary>
        /// Executes the use case.
        /// </summary>
        Task<TOutDTO> Execute();
    }

    /// <summary> 
    /// An Service executes business logic for a use case.
    /// </summary>
    public interface IService<in TInDTO, TOutDTO>
    {
        /// <summary>
        /// Executes the use case.
        /// </summary>
        /// <param name="inDTO">Encapsulated inDTO parameters.</param>
        TOutDTO Execute(TInDTO inDTO);


    }

    /// <summary> 
    /// An Service executes business logic for a use case.
    /// </summary>
    public interface IService<TOutDTO>
    {
        /// <summary>
        /// Executes the use case.
        /// </summary>
        TOutDTO Execute();
    }
}
