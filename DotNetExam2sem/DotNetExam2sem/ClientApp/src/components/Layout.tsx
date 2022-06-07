import * as React from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';

export interface LayoutComponentProps {
    children: React.ReactNode
}


export function Layout({children} : LayoutComponentProps) {
    return (
        <div>
            <NavMenu />
            <Container>
                {children}
            </Container>
        </div>
    )
}