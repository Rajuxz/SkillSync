import { createBrowserRouter } from 'react-router';
import {
  Hero,
  PublicRoute,
  ProtectedRoute,
  LoginForm,
  Dashboard,
  Layout,
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
        <Layout />
      </ProtectedRoute>
    ),
    children: [
      {
        index: true,
        element: <Dashboard />,
      },
    ],
  },
]);

export default router;
