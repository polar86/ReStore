import { Button, Divider, Paper, Typography } from '@mui/material';
import { Container } from '@mui/system';
import { useLocation, useNavigate } from 'react-router-dom';

export default function ServerError() {
  const navigate = useNavigate();
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  const { state } = useLocation() as any;
  return (
    <Container component={Paper}>
      {state?.error ? (
        <>
          <Typography variant="h3" color='error' gutterBottom>
            {state.error.title}
          </Typography>
          <Divider />
          <Typography>{state.error.detail || 'Internal server error'}</Typography>
        </>
      ) : (
        <Typography variant="h5" gutterBottom>
          Server error
        </Typography>
      )}
      <Button onClick={() => navigate('/catalog')}>Go Back to the Catalog</Button>
    </Container>
  );
}
