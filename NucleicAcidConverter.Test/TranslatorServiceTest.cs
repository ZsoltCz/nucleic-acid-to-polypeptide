using NucleicAcidConverter.Model;
using NucleicAcidConverter.Service;

namespace NucleicAcidConverter.Test;

[TestFixture]
public class TranslatorServiceTest
{
    private ITranslatorService _translatorService;

    private static readonly object[] TranslationTestCases =
    {
        
    };

    [OneTimeSetUp]
    public void Init()
    {
        var aminoAcidProviderService = new AminoAcidProviderService();
        _translatorService = new TranslatorService(aminoAcidProviderService);
    }

    [TestCaseSource(nameof(TranslationTestCases))]
    public void TranslatesSequenceCorrectly(Sequence sequence, string[] expectedResult)
    {
        var actual = _translatorService.TranslateSequence(sequence).Select(aminoAcid => aminoAcid.OneLetterSymbol);
        
        Assert.That(actual, Is.EqualTo(expectedResult));
    }
}