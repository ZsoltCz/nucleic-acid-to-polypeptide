using Microsoft.AspNetCore.Mvc;
using NucleicAcidConverter.Model;
using NucleicAcidConverter.Service;

namespace NucleicAcidConverter.Controllers;

[ApiController]
public class SequenceController : ControllerBase
{
    private readonly ITranslatorService _translatorService;
    private readonly ISequenceService _sequenceService;

    public SequenceController(ITranslatorService translatorService, ISequenceService sequenceService)
    {
        _translatorService = translatorService;
        _sequenceService = sequenceService;
    }

    [HttpGet]
    [Route("translate")]
    public ActionResult<IEnumerable<AminoAcid>> Translate([FromQuery]SequenceDto sequenceDto)
    {
        try
        {
            var sequence = _sequenceService.CreateSequence(sequenceDto);
            var polypeptideChain = _translatorService.TranslateSequence(sequence);
            return Ok(polypeptideChain);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
}