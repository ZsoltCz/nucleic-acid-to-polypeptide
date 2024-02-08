const divStyleTemp = {
  display: "inline",
  marginRight: "15px"
};

export default function ResultDisplay({ translationResult }) {
  
  return (
    translationResult.map((aminoAcid, index) => <div key={index} style={divStyleTemp}>{aminoAcid.name}</div>)
  );
};