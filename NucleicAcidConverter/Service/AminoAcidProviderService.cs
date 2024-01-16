using NucleicAcidConverter.Model;

namespace NucleicAcidConverter.Service;

public class AminoAcidProviderService : IAminoAcidProviderService
{
    private static readonly IDictionary<AminoAcid, string[]> AminoAcidCodonMap = new Dictionary<AminoAcid, string[]>()
    {
        { new AminoAcid("Alanine", "Ala", "A"), new string[] { "GCU", "GCC", "GCA", "GCG" } },
        { new AminoAcid("Arginine", "Arg", "R"), new string[] { "CGU", "CGC", "CGA", "CGG", "AGA", "AGG" } },
        { new AminoAcid("Asparagine", "Asn", "N"), new string[] { "AAU", "AAC" } },
        { new AminoAcid("Aspartic Acid", "Asp", "D"), new string[] { "GAU", "GAC" } },
        { new AminoAcid("Cysteine", "Cys", "C"), new string[] { "UGU", "UGC" } },
        { new AminoAcid("Glutamic Acid", "Glu", "E"), new string[] { "GAA", "GAG" } },
        { new AminoAcid("Glutamine", "Gln", "Q"), new string[] { "CAA", "CAG" } },
        { new AminoAcid("Glycine", "Gly", "G"), new string[] { "GGU", "GGC", "GGA", "GGG" } },
        { new AminoAcid("Histidine", "His", "H"), new string[] { "CAU", "CAC" } },
        { new AminoAcid("Isoleucine", "Ile", "I"), new string[] { "AUU", "AUC", "AUA" } },
        { new AminoAcid("Leucine", "Leu", "L"), new string[] { "UUA", "UUG", "CUU", "CUC", "CUA", "CUG" } },
        { new AminoAcid("Lysine", "Lys", "K"), new string[] { "AAA", "AAG" } },
        { new AminoAcid("Methionine", "Met", "M"), new string[] { "AUG" } },
        { new AminoAcid("Phenylalanine", "Phe", "F"), new string[] { "UUU", "UUC" } },
        { new AminoAcid("Proline", "Pro", "P"), new string[] { "CCU", "CCC", "CCA", "CCG" } },
        { new AminoAcid("Serine", "Ser", "S"), new string[] { "UCU", "UCC", "UCA", "UCG", "AGU", "AGC" } },
        { new AminoAcid("Threonine", "Thr", "T"), new string[] { "ACU", "ACC", "ACA", "ACG" } },
        { new AminoAcid("Tryptophan", "Trp", "W"), new string[] { "UGG" } },
        { new AminoAcid("Tyrosine", "Tyr", "Y"), new string[] { "UAU", "UAC" } },
        { new AminoAcid("Valine", "Val", "V"), new string[] { "GUU", "GUC", "GUA", "GUG" } },
        { new AminoAcid("Stop Codon", "Stop", "*"), new string[] { "UAA", "UAG", "UGA" } }
    };

    public AminoAcid GetAminoAcid(string codon)
    {
        return AminoAcidCodonMap.First(entry => entry.Value.Contains(codon)).Key;
    }
}