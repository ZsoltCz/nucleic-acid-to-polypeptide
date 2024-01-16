using NucleicAcidConverter.Model;

namespace NucleicAcidConverter.Service;

public class TranslatorService : ITranslatorService
{
    private readonly IAminoAcidProviderService _aminoAcidProvider;

    public TranslatorService(IAminoAcidProviderService aminoAcidProvider)
    {
        _aminoAcidProvider = aminoAcidProvider;
    }

    public IEnumerable<AminoAcid> TranslateSequence(Sequence sequence)
    {
        return sequence.Select(_aminoAcidProvider.GetAminoAcid);
    }
}