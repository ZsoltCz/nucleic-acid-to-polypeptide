using Microsoft.AspNetCore.Mvc;
using NucleicAcidConverter.Model;
using NucleicAcidConverter.Service;

namespace NucleicAcidConverter.Controllers;

[ApiController]
public class SequenceController : ControllerBase
{
    private readonly ITranslatorService _translatorService;

    public SequenceController(ITranslatorService translatorService)
    {
        _translatorService = translatorService;
    }

    [HttpGet]
    [Route("translate")]
    public IEnumerable<AminoAcid> Translate(Sequence sequence)
    {
        return _translatorService.TranslateSequence(sequence);
    }
}