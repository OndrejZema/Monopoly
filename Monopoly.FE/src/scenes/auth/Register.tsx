import { faArrowRight } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import React from "react";
import { Button, Card, CardBody, Form } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";

export const Register = () => {

    const navigate = useNavigate()
    const [email, setEmail] = React.useState<string>("")
    const [password, setPassword] = React.useState<string>("")
    const [confirmPassword, setConfirmPassword] = React.useState<string>("")
    const handleClick = () =>{
        fetch(`${process.env.REACT_APP_BE}/register`, 
{
            method: "POST",
            headers: {
                'Content-type': 'application/json'
            },
            body: JSON.stringify({email, password, confirmPassword})}
        ).then(() => navigate("/login")).catch(err => console.log(err))
    }

  return (
    <div className="d-flex justify-content-center mt-5">
      <Card className="d-flex flex-column">
        <CardBody>
          <h1>Register</h1>
          <div className="text-secondary">Already have an account?<Link to="/login">Login</Link></div>
          <Form.Label>E-mail</Form.Label>
          <Form.Control type="email" value={email} onChange={(e) => setEmail(e.target.value)} />
          <Form.Label>Password</Form.Label>
          <Form.Control type="password" value={password} onChange={(e) => setPassword(e.target.value)} />
          <Form.Label>Confirm password</Form.Label>
          <Form.Control type="password" value={confirmPassword} onChange={(e) => setConfirmPassword(e.target.value)} />
          <div className="d-flex justify-content-end">
          <Button onClick={handleClick} className="mt-2"><FontAwesomeIcon icon={faArrowRight} /> Register</Button>
          </div>
        </CardBody>
      </Card>
    </div>
  );
};
