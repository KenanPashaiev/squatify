import * as React from "react"
import Svg, { Path } from "react-native-svg"

function DateSelectIconSvg(props) {
    return (
        <Svg
            xmlns="http://www.w3.org/2000/svg"
            fill='none'
            viewBox="0 0 24 24"
            width={20} height={20}
            {...props}>
            <Path
                fillRule="evenodd"
                d="M6 2v2H5c-1.1 0-2 .9-2 2v14c0 1.1.9 2 2 2h14c1.1 0 2-.9 2-2V6c0-1.1-.9-2-2-2h-1V2h-2v2H8V2H6zM5 9h14v11H5V9zm7 4v5h5v-5h-5z"
            ></Path>
        </Svg>
    );
}

export default DateSelectIconSvg;
