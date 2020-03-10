import React from "react";
import { Dimmer, Loader } from "semantic-ui-react";

/* active: display it only when it's active
   ?question mark makes it optional 
   inverted: set dark/light
*/
const LoadingComponent: React.FC<{
  inverted?: boolean;
  content?: string;
}> = props => {
  const { inverted, content } = props;
  return (
    <Dimmer active inverted={inverted || true}>
      <Loader content={content} />
    </Dimmer>
  );
};

export default LoadingComponent;
