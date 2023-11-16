using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductDetails.DTO;
using ProductDetails.Model;
using ProductDetails.Repository;
using ProductDetails.Repository.IRepository;

namespace ProductDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueDetailController : ControllerBase
    {
        private readonly IIssueDetailRepository _issueDetailRepository;
        private readonly IMapper _mapper;

        public IssueDetailController(IIssueDetailRepository issueDetailRepository, IMapper mapper)
        {
            _issueDetailRepository = issueDetailRepository;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<CreateIssueDetailDto>> Create([FromBody] CreateIssueDetailDto issueDetailDto)
        {

            var issuedetail = _mapper.Map<IssueDetail>(issueDetailDto);

            await _issueDetailRepository.Create(issuedetail);

            return Ok();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<GetIssueDetailDto>>> GetAll()
        {
            var issuesDetail = await _issueDetailRepository.GetAll();

            var issuesDto = _mapper.Map<List<GetIssueDetailDto>>(issuesDetail);

            if (issuesDetail == null)
            {
                return NoContent();
            }
            return Ok(issuesDto);
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<GetIssueDetailDto>> GetById(int id)
        {

            var issue = await _issueDetailRepository.Get(id);
            var issuesDto = _mapper.Map<GetIssueDetailDto>(issue);

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

        public async Task<ActionResult<CreateIssueDetailDto>> Update(int id, [FromBody] CreateIssueDetailDto issueDetailDto)
        {
            if (issueDetailDto == null || id != issueDetailDto.Id)
            {
                return BadRequest();
            }

            var issueDetail = _mapper.Map<IssueDetail>(issueDetailDto);

            await _issueDetailRepository.Update(issueDetail);
            return Ok(issueDetail); // Return the updated object with keys and values
        }
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<IssueDetail>> DeleteById(int id)
        {
            var issueDetail = await _issueDetailRepository.Get(id);
            if (issueDetail == null)
            {
                return NotFound();
            }
            await _issueDetailRepository.Delete(issueDetail);
            return issueDetail;

        }

    }
}
