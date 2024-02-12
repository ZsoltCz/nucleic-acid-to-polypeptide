const divStyleTemp = {
  display: "inline",
  marginRight: "15px"
};

export default function ResultDisplay({ translationResult, displayedProperty }) {
  
  return (
    translationResult.map((aminoAcid, index) => <div key={index} style={divStyleTemp}>{aminoAcid[displayedProperty]}</div>)
  );
};