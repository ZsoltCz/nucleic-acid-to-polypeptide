using NucleicAcidConverter.Model;

namespace NucleicAcidConverter.Service;

public class AminoAcidProviderService : IAminoAcidProviderService
{
    private static readonly IDictionary<AminoAcid, string[]> AminoAcidCodonMap = new Dictionary<AminoAcid, string[]>
    {
        { new AminoAcid("Alanine", "Ala", "A"), new[] { "GCU", "GCC", "GCA", "GCG" } },
        { new AminoAcid("Arginine", "Arg", "R"), new[] { "CGU", "CGC", "CGA", "CGG", "AGA", "AGG" } },
        { new AminoAcid("Asparagine", "Asn", "N"), new[] { "AAU", "AAC" } },
        { new AminoAcid("Aspartic Acid", "Asp", "D"), new[] { "GAU", "GAC" } },
        { new AminoAcid("Cysteine", "Cys", "C"), new[] { "UGU", "UGC" } },
        { new AminoAcid("Glutamic Acid", "Glu", "E"), new[] { "GAA", "GAG" } },
        { new AminoAcid("Glutamine", "Gln", "Q"), new[] { "CAA", "CAG" } },
        { new AminoAcid("Glycine", "Gly", "G"), new[] { "GGU", "GGC", "GGA", "GGG" } },
        { new AminoAcid("Histidine", "His", "H"), new[] { "CAU", "CAC" } },
        { new AminoAcid("Isoleucine", "Ile", "I"), new[] { "AUU", "AUC", "AUA" } },
        { new AminoAcid("Leucine", "Leu", "L"), new[] { "UUA", "UUG", "CUU", "CUC", "CUA", "CUG" } },
        { new AminoAcid("Lysine", "Lys", "K"), new[] { "AAA", "AAG" } },
        { new AminoAcid("Methionine", "Met", "M"), new[] { "AUG" } },
        { new AminoAcid("Phenylalanine", "Phe", "F"), new[] { "UUU", "UUC" } },
        { new AminoAcid("Proline", "Pro", "P"), new[] { "CCU", "CCC", "CCA", "CCG" } },
        { new AminoAcid("Serine", "Ser", "S"), new[] { "UCU", "UCC", "UCA", "UCG", "AGU", "AGC" } },
        { new AminoAcid("Threonine", "Thr", "T"), new[] { "ACU", "ACC", "ACA", "ACG" } },
        { new AminoAcid("Tryptophan", "Trp", "W"), new[] { "UGG" } },
        { new AminoAcid("Tyrosine", "Tyr", "Y"), new[] { "UAU", "UAC" } },
        { new AminoAcid("Valine", "Val", "V"), new[] { "GUU", "GUC", "GUA", "GUG" } },
        { new AminoAcid("Stop Codon", "Stop", "*"), new[] { "UAA", "UAG", "UGA" } }
    };

    public AminoAcid GetAminoAcid(string codon)
    {
        return AminoAcidCodonMap.First(entry => entry.Value.Contains(codon)).Key;
    }
}