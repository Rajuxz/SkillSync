import React, { useEffect } from 'react';
import useAuthStore from '../../store/authStore';
import { Navigate } from 'react-router';
const ProtectedRoute = ({ children }) => {
  const { isAuthorized, isLoading, checkAuth } = useAuthStore();

  useEffect(() => {
    if (isAuthorized === null) {
      checkAuth();
    }
  }, [isAuthorized, checkAuth]);

  if (isLoading || isAuthorized === null) {
    return <p className="animate-bounce">Checking Connection ....</p>;
  }

  if (!isAuthorized) {
    return <Navigate to="/login" replace />;
  }

  return children;
};

export default ProtectedRoute;
