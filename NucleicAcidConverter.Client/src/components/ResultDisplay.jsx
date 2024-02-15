import { CircularProgress, Container } from "@mui/material";

const divStyleTemp = {
  display: "inline",
  marginRight: "15px"
};

export default function ResultDisplay({ translationResult, displayedProperty, loading }) {
  
  return (
    <Container>
      {loading ? (
        <CircularProgress />
      ) : (
        translationResult.map((aminoAcid, index) => (
          <div key={index} style={divStyleTemp}>
            {aminoAcid[displayedProperty]}
          </div>
        ))
      )}
    </Container>
  );
};