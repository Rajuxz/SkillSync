import { createBrowserRouter } from 'react-router';
import {
  Hero,
  PublicRoute,
  ProtectedRoute,
  LoginForm,
} from './components/index.js';

const router = createBrowserRouter([
  {
    path: '/',
    element: (
      <PublicRoute>
        <Hero />,
      </PublicRoute>
    ),
    index: true,
  },
  {
    path: '/login',
    element: (
      <PublicRoute>
        <LoginForm />,
      </PublicRoute>
    ),
  },
  {
    path: '/dashboard',
    element: (
      <ProtectedRoute>
        <h1>Hello Dashboard.</h1>
      </ProtectedRoute>
    ),
  },
]);

export default router;
