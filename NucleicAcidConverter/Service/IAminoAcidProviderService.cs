using NucleicAcidConverter.Model;

namespace NucleicAcidConverter.Service;

public interface IAminoAcidProviderService
{
    public AminoAcid GetAminoAcid(string codon);
}