import * as React from "react"
import Svg, { Path } from "react-native-svg"

const AccountIconSvg = (props) => (
  <Svg
    xmlns="http://www.w3.org/2000/svg"
    fill='none'
    viewBox="0 0 24 24"
    width={20} height={20}
    {...props}
  >
    <Path
      fillRule="evenodd"
      clipRule="evenodd"
      d="M12 3a4 4 0 1 0 0 8 4 4 0 0 0 0-8Zm3.774 8.665a6 6 0 1 0-7.548 0c-3.887 1.42-6.749 4.97-7.172 9.238C.934 22.107 1.925 23 3 23h18c1.075 0 2.065-.893 1.946-2.097-.423-4.268-3.285-7.819-7.172-9.238ZM12 13a9.001 9.001 0 0 0-8.945 8h17.89c-.497-4.5-4.313-8-8.945-8Z"
    />
  </Svg>
)



export default AccountIconSvg
