using NucleicAcidConverter.Model;

namespace NucleicAcidConverter.Service;

public interface ITranslatorService
{
    public IEnumerable<AminoAcid> TranslateSequence(Sequence sequence);
}