using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductDetails.DTO;
using ProductDetails.Model;
using ProductDetails.Repository.IRepository;
using System.Diagnostics.Metrics;

namespace ProductDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuesController : ControllerBase
    {
        private readonly IIssueRepository _issueRepository;
        private readonly IMapper _mapper;

        public IssuesController(IIssueRepository issueRepository, IMapper mapper)
        {
            _issueRepository = issueRepository;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<CreateIssueDto>> Create([FromBody] CreateIssueDto issueDto)
        { 

            var issue = _mapper.Map<Issues>(issueDto);

            await _issueRepository.Create(issue);

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<GetIssueDto>>> GetAll()
        {
            var issues = await _issueRepository.GetAll();

            var issuesDto = _mapper.Map<List<GetIssueDto>>(issues);

            if (issues == null)
            {
                return NoContent();
            }
            return Ok(issuesDto);
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<GetIssueDto>> GetById(int id)
        {

            var issue = await _issueRepository.Get(id);
            var issuesDto = _mapper.Map<GetIssueDto>(issue);



            if (issue == null)
            {
                return NoContent();
            }
            return Ok(issuesDto);
        }
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<CreateIssueDto>> Update(int id, [FromBody] CreateIssueDto issueDto)
        {
            if (issueDto == null || id != issueDto.Id)
            {
                return BadRequest();
            }

            var issue = _mapper.Map<Issues>(issueDto);

            await _issueRepository.Update(issue);
            return Ok(issue); // Return the updated object with keys and values
        }
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Issues>> DeleteById(int id)
        {
            var issue = await _issueRepository.Get(id);
            if (issue == null)
            {
                return NotFound();
            }
            await _issueRepository.Delete(issue);
            return issue;

        }
        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetIssueDto>>> SearchByEntityId([FromQuery] string entityId)
        {
            // Check if issues with the provided entityId exist in your data
            var issues = await _issueRepository.SearchByPartialEntityId(entityId);

            if (issues.Count == 0)
            {
                return NotFound("No matching issues found");
            }

            var issuesDto = _mapper.Map<List<GetIssueDto>>(issues);
            return Ok(issuesDto);
        }
    
    }
}
