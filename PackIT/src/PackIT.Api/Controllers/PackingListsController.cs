using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PackIT.Application.Commands;
using PackIT.Application.DTO;
using PackIT.Application.Queries;
using PackIT.Shared.Abstractions.Commands;
using PackIT.Shared.Abstractions.Queries;

namespace PackIT.Api.Controllers
{
    public class PackingListsController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher) : BaseController
    {
        private readonly ICommandDispatcher _commandDispatcher = commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher = queryDispatcher;

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PackingListDto>> GetAsync([FromRoute] GetPackingList query)
        {
            var result = await _queryDispatcher.QueryAsync(query);
            return OkOrNotFound(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PackingListDto>>> GetAsync([FromQuery] SearchPackingLists query)
        {
            var result = await _queryDispatcher.QueryAsync(query);
            return OkOrNotFound(result);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] CreatePackingListWithItems command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return CreatedAtAction(nameof(GetAsync), new { id = command.Id });
        }

        [HttpPut("{packingListId}/items")]
        public async Task<IActionResult> PutAsync([FromBody] AddPackingItem command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }

        [HttpPut("{packingListId:guid}/items/{name}/pack")]
        public async Task<IActionResult> PutAsync([FromBody] PackItem command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }

        [HttpDelete("{packingListId:guid}/items/{name}")]
        public async Task<IActionResult> DeleteAsync([FromBody] RemovePackingItem command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync([FromBody] RemovePackingList command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }
    }
}
