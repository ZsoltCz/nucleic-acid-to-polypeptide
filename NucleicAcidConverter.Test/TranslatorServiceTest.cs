using NucleicAcidConverter.Service;

namespace NucleicAcidConverter.Test;

[TestFixture]
public class TranslatorServiceTest
{
    private ITranslatorService _translatorService;
    
    [OneTimeSetUp]
    public void Init()
    {
        var aminoAcidProviderService = new AminoAcidProviderService();
        _translatorService = new TranslatorService(aminoAcidProviderService);
    }
}