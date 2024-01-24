using NucleicAcidConverter.Service;

namespace NucleicAcidConverter.Test;

[TestFixture]
public class TranslatorServiceTest
{
    private ITranslatorService _translatorService;

    public TranslatorServiceTest(ITranslatorService translatorService)
    {
        IAminoAcidProviderService aminoAcidProvider = new AminoAcidProviderService();
        _translatorService = new TranslatorService(aminoAcidProvider);
    }
}