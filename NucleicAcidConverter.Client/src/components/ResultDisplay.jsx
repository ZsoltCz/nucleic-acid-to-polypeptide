import { CircularProgress, Container, List, ListItem, Typography } from "@mui/material";

const divStyleTemp = {
  display: "inline"
};

export default function ResultDisplay({ translationResult, displayedProperty, loading }) {
  
  return (
    <Container>
      {loading ? (
        <CircularProgress />
      ) : (
        <Typography>
          <List>
            {translationResult.map((aminoAcid, index) => (
              <ListItem key={index} style={divStyleTemp}>
                {aminoAcid[displayedProperty]}
              </ListItem>
            ))}
          </List>
        </Typography>
      )}
    </Container>
  );
};
